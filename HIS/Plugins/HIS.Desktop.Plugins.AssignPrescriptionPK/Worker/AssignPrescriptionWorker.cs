/* IVT
 * @Project : hisnguonmo
 * Copyright (C) 2017 INVENTEC
 *  
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *  
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *  
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
namespace HIS.Desktop.Plugins.AssignPrescriptionPK
{
    class AssignPrescriptionWorker : IDisposable
    {
        public MediMatyCreateWorker MediMatyCreateWorker { get; set; }

        public void Dispose()
        {
            MediMatyCreateWorker = null;
        }

        public static AssignPrescriptionWorker Instance { get; private set; }
        public static void CreateInstance()
        {
            if (Instance == null)
                Instance = new AssignPrescriptionWorker();
        }

        static AssignPrescriptionWorker()
        {
            if (Instance == null)
                Instance = new AssignPrescriptionWorker();
        }

        public static void DisposeInstance()
        {
            if (Instance != null)
            {
                Instance.Dispose();
                Instance = null;
            }
        }
    }
}
