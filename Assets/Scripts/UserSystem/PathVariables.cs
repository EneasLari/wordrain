using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SerializationForGameTest.PersistentData {
    public static class PathVariables {
        public static string USERSMANAGERPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"EducationalGames\Users");

    }
}
