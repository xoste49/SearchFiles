using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchFiles
{
   public partial class Form1 : Form
   {
      // + Все найденные по критериям файлы в виде дерева(как в левой части проводника)

      // + 1. Стартовая директория(с которой начинается поиск)

      // + 2. Шаблон имени файла

      // + 3. Набор символов, которые могут содержаться в файле

      // + 4. Сохранение директории, шаблона имени и набора символов

      // + Какой файл обрабатывается в данный момент

      // + Количество обработанных файлов

      // + Прошедшее от начала запуска поиска время

      //Пользователь должен иметь возможность остановить поиск в любой момент и затем либо продолжить его либо начать новый поиск.

      // + Затем пользователь нажимает кнопку Поиск и программа начинает отображать следующую информацию в режиме реального времени:

      // + Все найденные по критериям файлы в виде дерева(как в левой части проводника). Дерево не должно подвисать, моргать тормозить и т.д. Во время поиска пользователь может ходить по дереву, открывать/закрывать узлы.


      private int countFiles = 0;
      private int CountFiles
      {
         get { return countFiles; }
         set
         {
            Invoke(new MethodInvoker(() => { lCountFiles.Text = "Колличество найденных файлов: " + value.ToString(); }));
            countFiles = value;
         }
      }

      Stopwatch stopWatch = new Stopwatch();

      public Form1()
      {
         InitializeComponent();
         if (!string.IsNullOrEmpty(Properties.Settings.Default.Path)) tPath.Text = Properties.Settings.Default.Path;
         if (!string.IsNullOrEmpty(Properties.Settings.Default.SearchContent)) tSearchContent.Text = Properties.Settings.Default.SearchContent;
         if (!string.IsNullOrEmpty(Properties.Settings.Default.SearchMask)) tSearchMask.Text = Properties.Settings.Default.SearchMask;
      }

      // Выбор папки
      private void bPathSearch_Click(object sender, EventArgs e)
      {
         fBrowserDialog.ShowDialog();
         tPath.Text = fBrowserDialog.SelectedPath;
      }


      private async void bSearch_Click(object sender, EventArgs e)
      {
         //await Search();
         bSearch.Enabled = false;
         await Task.Factory.StartNew(Search);
         bSearch.Enabled = true;
      }


      public void Search()
      {
         // Очистка
         Invoke(new MethodInvoker(() => {   tvResultSearch.Nodes.Clear();   }));
         CountFiles = 0;
         stopWatch.Reset();

         // Запуск таймера
         stopWatch.Start(); 
         TreeNode treeNode = new TreeNode(tPath.Text);
         Invoke(new MethodInvoker(() => { 
            tvResultSearch.Nodes.Add(treeNode);
            treeNode.Expand();
         }));
         AddDirectories(treeNode);
         // Считываем дерево

         // Остановка таймера
         stopWatch.Stop(); 
      }

      // Рекурсивный метод
      void AddDirectories(TreeNode node)
      {
         // Для текущего узла node получаем полный путь к корню дерева
         string strPath = node.FullPath;
         // Создаем объект текущего каталога
         DirectoryInfo dirInfo = new DirectoryInfo(strPath);
         // Объявляем ссылку на массив подкаталогов текущего каталога
         DirectoryInfo[] directoryInfos;
         FileInfo[] fileInfos;
         try
         {
            // Пытаемся получить список подкаталогов
            directoryInfos = dirInfo.GetDirectories();
            // Добавляем прочитанные подкаталоги как узлы в дерево просмотра
            foreach (DirectoryInfo dir in directoryInfos)
            {
               // Создаем новый узел с именем подкаталога
               TreeNode nodeDir = new TreeNode(dir.Name);
               // Добавляем его как дочерний к текущему узлу
               Invoke(new MethodInvoker(() => { node.Nodes.Add(nodeDir); }));
               //node.Nodes.Add(nodeDir);
               // Делаем дочерний узел текущим и спускаемся рекурсивно ниже
               AddDirectories(nodeDir);
            }
         } catch { throw; }
         try
         {
            // Пытаемся получить список файлов по маске
            if (!string.IsNullOrEmpty(tSearchMask.Text)) { fileInfos = dirInfo.GetFiles(tSearchMask.Text); } else { fileInfos = dirInfo.GetFiles(); }

            // Если строка поиска по содержимому не пуска то выполняем поиск по содержимому
            if (!string.IsNullOrEmpty(tSearchContent.Text))
            {
               foreach (FileInfo f in fileInfos)
               {
                  Invoke(new MethodInvoker(() => { tsslCurrentFile.Text = f.FullName; }));
                  string text = File.ReadAllText(f.FullName);
                  if (text.Contains(tSearchContent.Text))
                  {
                     Invoke(new MethodInvoker(() => { node.Nodes.Add(f.Name); }));
                     //node.Nodes.Add(f.Name);
                     CountFiles++;
                  }
               }
            } else
            {
               foreach (FileInfo f in fileInfos)
               {
                  Invoke(new MethodInvoker(() => { node.Nodes.Add(f.Name); }));
                  //node.Nodes.Add(f.Name);
                  Invoke(new MethodInvoker(() => { tsslCurrentFile.Text = f.FullName;}));
                  CountFiles++;
               }
            }
         } catch { throw; }
         // Развертываем
         Invoke(new MethodInvoker(() => { node.Expand(); })); 
         if (node.Nodes.Count == 0) { 
            Invoke(new MethodInvoker(() => { node.Remove(); })); 
            node.Remove();
         }

      }

      private void tPath_TextChanged(object sender, EventArgs e)
      {
         Properties.Settings.Default.Path = tPath.Text;
         Properties.Settings.Default.Save();
      }

      private void tSearchMask_TextChanged(object sender, EventArgs e)
      {
         Properties.Settings.Default.SearchMask = tSearchMask.Text;
         Properties.Settings.Default.Save();
      }

      private void tSearchContent_TextChanged(object sender, EventArgs e)
      {
         Properties.Settings.Default.SearchContent = tSearchContent.Text;
         Properties.Settings.Default.Save();
      }

      private void timerTimeSum_Tick(object sender, EventArgs e)
      {
         TimeSpan ts = stopWatch.Elapsed;
         string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
         tsslCurrentTime.Text = elapsedTime;
      }
   }

}
