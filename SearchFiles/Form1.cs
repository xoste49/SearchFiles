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

      //Затем пользователь нажимает кнопку Поиск и программа начинает отображать следующую информацию в режиме реального времени:

      //Все найденные по критериям файлы в виде дерева(как в левой части проводника). Дерево не должно подвисать, моргать тормозить и т.д. Во время поиска пользователь может ходить по дереву, открывать/закрывать узлы.


      private int countFiles = 0;
      private int CountFiles
      {
         get { return countFiles; }
         set
         {
            lCountFiles.Text = "Колличество найденных файлов: " + value.ToString();
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


      private void bSearch_Click(object sender, EventArgs e)
      {
         Search();
      }


      public void Search()
      {
         // Запуск таймера
         stopWatch.Start(); 
         // Очистка
         tvResultSearch.Nodes.Clear();
         CountFiles = 0;
         TreeNode treeNode = new TreeNode(tPath.Text);
         tvResultSearch.Nodes.Add(treeNode);
         treeNode.Expand();
         // Считываем дерево
         AddDirectories(treeNode);
         // Остановка таймера
         stopWatch.Stop(); 
         //timerTimeSum.Enabled = false;
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
               node.Nodes.Add(nodeDir);
               // Делаем дочерний узел текущим и спускаемся рекурсивно ниже
               AddDirectories(nodeDir);
            }
         } catch { }
         try
         {
            // Пытаемся получить список файлов по маске
            if (!string.IsNullOrEmpty(tSearchMask.Text)) { fileInfos = dirInfo.GetFiles(tSearchMask.Text); } else { fileInfos = dirInfo.GetFiles(); }

            // Если строка поиска по содержимому не пуска то выполняем поиск по содержимому
            if (!string.IsNullOrEmpty(tSearchContent.Text))
            {
               foreach (FileInfo f in fileInfos)
               {
                  string text = File.ReadAllText(f.FullName);
                  tsslCurrentFile.Text = f.FullName;
                  if (text.Contains(tSearchContent.Text))
                  {
                     node.Nodes.Add(f.Name);
                     CountFiles++;
                  }
               }
            } else
            {
               foreach (FileInfo f in fileInfos)
               {
                  node.Nodes.Add(f.Name);
                  tsslCurrentFile.Text = f.FullName;
                  CountFiles++;
               }
            }
         } catch { }
         // Развертываем
         //node.Expand();
         if (node.Nodes.Count == 0) node.Remove();
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
