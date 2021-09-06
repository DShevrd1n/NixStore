using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Store.Web.App
{
    public static class SessionExtension
    {
        private const string key = "Cart";
        public static void Set(this ISession sesion, Cart value)
        {
            if (value == null)
                return;
            using(var stream = new MemoryStream())
            using(var writer = new BinaryWriter(stream,Encoding.UTF8, true))
            {
                writer.Write(value.OrderId);
                writer.Write(value.TotalCount);
                writer.Write(value.TotalPrice);

                sesion.Set(key, stream.ToArray());
            }
        }
        public static bool TryGetCart(this ISession sesion,out Cart value)
        {
            if(sesion.TryGetValue(key,out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    var orderId = reader.ReadInt32();
                    var totalCount = reader.ReadInt32();
                    var totalPrice = reader.ReadDecimal();

                    value = new Cart(orderId, totalCount, totalPrice);
                 
                    return true;
                }
            }
            value = null;
            return false;
        }
    }
}
