﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchFiles
{
   public partial class Form1 : Form
   {
      // Программа будет использоваться для поиска файлов на диске
      // Пользователь следующие критерии и они должны быть сохранены при перезапуске программы:
      // + 1. Стартовая директория(с которой начинается поиск)

      //2. Шаблон имени файла

      //3. Набор символов, которые могут содержаться в файле


      //Затем пользователь нажимает кнопку Поиск и программа начинает отображать следующую информацию в режиме реального времени:

      //Все найденные по критериям файлы в виде дерева(как в левой части проводника). Дерево не должно подвисать, моргать тормозить и т.д.Во время поиска пользователь может ходить по дереву, открывать/закрывать узлы.
      //Какой файл обрабатывается в данный момент
      //Количество обработанных файлов
      //Прошедшее от начала запуска поиска время
      //Пользователь должен иметь возможность остановить поиск в любой момент и затем либо продолжить его либо начать новый поиск.
      public Form1()
      {
         InitializeComponent();
      }

      private void bPathSearch_Click(object sender, EventArgs e)
      {
         fBrowserDialog.ShowDialog();
         tPath.Text = fBrowserDialog.SelectedPath;
      }

      private void bSearch_Click(object sender, EventArgs e)
      {
         TreeNode treeNode = new TreeNode(tPath.Text);
         tvResultSearch.Nodes.Add(treeNode);
         treeNode.Expand();
         // Считываем дерево каталогов
         AddDirectories(treeNode);
      }

      // Рекурсивный метод
      void AddDirectories(TreeNode node)
      {
         // Для текущего узла node получаем полный путь к корню дерева
         string strPath = node.FullPath;
         // Создаем объект текущего каталога
         DirectoryInfo dirInfo = new DirectoryInfo(strPath);
         // Объявляем ссылку на массив подкаталогов текущего каталога
         DirectoryInfo[] arrayDirInfo;

         try
         {
            // Пытаемся получить список подкаталогов
            arrayDirInfo = dirInfo.GetDirectories();
         } catch
         {
            // Подкаталогов нет, выходим из рекурсии
            return;
         }

         // Добавляем прочитанные подкаталоги как узлы в дерево просмотра
         foreach (DirectoryInfo dir in arrayDirInfo)
         {
            // Создаем новый узел с именем подкаталога
            TreeNode nodeDir = new TreeNode(dir.Name);
            // Добавляем его как дочерний к текущему узлу
            node.Nodes.Add(nodeDir);
            // Развертываем узел
            //nodeDir.Expand();
            // Делаем дочерний узел текущим и спускаемся рекурсивно ниже
            AddDirectories(nodeDir);
         }
      }

     
   }
}