using ShopManagerMini.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Vong lap de co the dang xuat roi dang nhap lai
            while (true)
            {
                User currentUser;

                // Hien form dang nhap bang ShowDialog, dong lai moi chay tiep
                using (FrmLogin frmLogin = new FrmLogin())
                {
                    if (frmLogin.ShowDialog() != DialogResult.OK)
                    {
                        break; // bam Thoat hoac tat form
                    }
                    currentUser = frmLogin.LoggedUser;
                }

                FrmMain frmMain = new FrmMain(currentUser);
                Application.Run(frmMain);

                // Neu khong phai dang xuat thi thoat han chuong trinh
                if (!frmMain.IsLogout)
                {
                    break;
                }
            }
        }
    }
}
