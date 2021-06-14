using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VirtualVendingMachine.Models;

namespace VirtualVendingMachine.Daos
{
    public class VendingMachineFileDao : IVendingMachineDao
    {
        string _filePath { get; set; }

        public VendingMachineFileDao(string filePath)
        {
            _filePath = filePath;
        }

        public VendingMachineFileDao() : this("../../../../Snacks.txt")
        {

        }


        public List<Snack> GetInventory()
        {
            List<Snack> snacks = new List<Snack>();

            using (StreamReader read = new StreamReader(_filePath))
            {
                string line = null;
                while ((line = read.ReadLine()) != null)
                {
                    string[] snackProps = line.Split(",");
                    Snack snackToAdd = new Snack(snackProps[0], decimal.Parse(snackProps[1]), int.Parse(snackProps[2]));

                    snacks.Add(snackToAdd);
                }
            }
            return snacks;
        }

        public void EditSnack(Snack snack)
        {
            var snacks = GetInventory().Select(s =>
                s.Name == snack.Name ?
                new Snack(s.Name, s.Price, s.Quantity - 1) : s).ToList();
        }

        public void WriteToFile(List<Snack> snacks)
        {
            string line = "";
            foreach(Snack s in snacks)
            {
                line += s.ToString();
            }
            File.WriteAllText(_filePath, line);
        }
    }
}

