using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordsHash
{
    public static class Constants
    {
        public static string AppDirectory { get; private set; }

        static Constants()
        {
            AppDirectory = findMyDir(new FileInfo(Assembly.GetExecutingAssembly().Location).FullName);
        }
        private static string findMyDir(string path)
        {
            if (path.EndsWith("PasswordsHash\\"))
            {
                return path;
            }
            else
                return findMyDir(path.Remove(path.Length - 1));
        }
    }
}
