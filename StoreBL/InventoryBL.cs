using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class InventoryBL : IInventoryBL
    {
        private ISQLInvRepository _repo;
        public InventoryBL(ISQLInvRepository p_repo)
        {
            _repo = p_repo;
        }


        public Inventory AddInventory(Inventory p_inv)
        {
            List<Inventory> listofInventory = _repo.GetAllInventory();
            Console.WriteLine("Adding Inventory............");
            return _repo.AddInventory(p_inv);
        }

        public List<Inventory> SearchLocationInventory(int p_storeID)
        {
            List<Inventory> listofInventory = _repo.GetAllInventory();
            return listofInventory
                    .Where(Inventory => Inventory.StoreID.Equals(p_storeID))
                    .ToList(); //ToList method converts into return List collection
        }


        public Inventory UpdateInventory(Inventory p_inv)
        {
            return _repo.UpdateInventory(p_inv);
        }



        public List<Inventory> GetAllInventory()
        {
            List<Inventory> listofinventory = _repo.GetAllInventory();
            return listofinventory;

        }
        

        
    }
}