using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTNCLaab4_5
{
    public class ItemManager
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item không được null.");
            if (string.IsNullOrWhiteSpace(item.Name) || !IsValidName(item.Name))
                throw new ArgumentException("Name phải là chữ và độ dài nhỏ hơn hoặc bằng 50.");

            items.Add(item);
        }

        public void UpdateItem(int id, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName) || !IsValidName(newName))
                throw new ArgumentException("Name phải là chữ và độ dài nhỏ hơn hoặc bằng 50.");

            var item = items.FirstOrDefault(x => x.Id == id);
            if (item == null)
                throw new KeyNotFoundException("Không tìm thấy Item với Id được cung cấp.");

            item.Name = newName;
        }

        public void DeleteItem(int id)
        {
            var removedCount = items.RemoveAll(i => i.Id == id);
            if (removedCount == 0)
                throw new KeyNotFoundException("Không tìm thấy Item với Id được cung cấp.");
        }

        private bool IsValidName(string name)
        {
            return name.Length <= 50 && name.All(char.IsLetter);
        }
    }

}
