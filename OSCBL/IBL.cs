using OSCDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCBL
{
    public interface IBL
    {
		int CheckLogin(Customer newObj);
		int checkadminlogin(Admin newadmin);
		int regsignup(Customer newObj1);
		int InsertintoProductTable(Product newObj1);
		int InsertintoCart(ADDCart newObj4);
		int DeleteProductItem(Product newObj2);
		List<Product> GetAllProductDetails();
		List<Product> AdminProductDetails();
		List<ADDCart> FetchCart();

	}
}
