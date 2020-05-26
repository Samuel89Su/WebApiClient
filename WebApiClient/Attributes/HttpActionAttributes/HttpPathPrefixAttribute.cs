using System;
using System.Threading.Tasks;
using WebApiClient.Contexts;

namespace WebApiClient.Attributes
{
    /// <summary>
    /// 为请求路径扩展前缀，
    /// 在有网关的情况下，一般请求路径中有一段固定路径表示特定服务
    /// </summary>
    public class HttpPathPrefixAttribute : ApiActionAttribute
    {
        /// <summary>
        /// 路径前缀
        /// </summary>
        public string Prefix { get; private set; }

        /// <summary>
        /// 路径前缀
        /// </summary>
        /// <param name="prefix">紧跟在 host 段之后的路径</param>
        public HttpPathPrefixAttribute(string prefix)
        {
            Prefix = prefix.StartsWith("/") ? prefix : ("/" + prefix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task BeforeRequestAsync(ApiActionContext context)
        {
            var uri = context.RequestMessage.RequestUri;

            context.RequestMessage.RequestUri = new Uri($"{uri.Scheme}://{uri.Host}{Prefix}{uri.PathAndQuery}");

            return ApiTask.CompletedTask;
        }
    }
}
