using System.Threading.Tasks;
using Android.Runtime;
using System.Collections.Generic;
using Ouya.Csharp.Purchaseutils;

namespace Ouya.Console.Api
{
    public partial class OuyaFacade
    {
        private PurchaseUtils _purchaseUtils;

        public void Init(Android.Content.Context context, string developerUuid, byte[] applicationKey, bool setTestMode)
        {
            Init(context, developerUuid);
            InitPurchaseUtils(applicationKey, setTestMode);
            if (setTestMode)
            {
                SetTestMode();
            }
        }

        private void InitPurchaseUtils(byte[] applicationKey, bool setTestMode)
        {
            _purchaseUtils = new PurchaseUtils(applicationKey, setTestMode);
        }

        public Task<string> RequestGamerUuid()
        {
            var tcs = new TaskCompletionSource<string>();
            RequestGamerUuid(new StringListener(tcs));
            return tcs.Task;
        }

        public Task<IList<Product>> RequestProductList(IList<Purchasable> purchasables)
        {
            var tcs = new TaskCompletionSource<IList<Product>>();
            RequestProductList(purchasables, new ProductListListener(tcs));
            return tcs.Task;
        }
        public Task<bool> RequestPurchase(string productId, string uniquePurchaseId)
        {
            var tcs = new TaskCompletionSource<bool>();
            var purchasable = _purchaseUtils.CreatePurchasable(productId, uniquePurchaseId);
            RequestPurchase(purchasable, new PurchaseListener(tcs, _purchaseUtils, productId, uniquePurchaseId));
            return tcs.Task;
        }

        public Task<IList<Receipt>> RequestReceipts()
        {
            var tcs = new TaskCompletionSource<IList<Receipt>>();
            RequestReceipts(new ReceiptsListener(tcs, _purchaseUtils));
            return tcs.Task;
        }
    }
}