using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web
{
    public static  class SessionExtension
    {
        private const string key = "Cart";
        public static void Set(this ISession sesion, Cart value)
        {
            if (value == null)
                return;
            using(var stream = new MemoryStream())
            using(var writer = new BinaryWriter(stream,Encoding.UTF8, true))
            {
                writer.Write(value.Items.Count);
                foreach(var item in value.Items)
                {
                    writer.Write(item.Key);
                    writer.Write(item.Value);
                }
                writer.Write(value.AmountPrice);
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
                    value = new Cart();
                    var length = reader.ReadInt32();
                    for(int i = 0; i < length; i++)
                    {
                        var productId = reader.ReadInt32();
                        var count = reader.ReadInt32();
                        value.Items.Add(productId, count);
                    }
                    value.AmountPrice = reader.ReadDecimal();
                    return true;
                }
            }
            value = null;
            return false;
        }
    }
}
