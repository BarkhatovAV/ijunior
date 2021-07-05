using System;

namespace ijunior
{
    internal class Shop
    {
        public Shop(Warehouse warehouse)
        {
            Warehouse = warehouse;
        }

        public Warehouse Warehouse { get; }

        public Cart Cart()
        {
            return new Cart(Warehouse);
        }
    }
}