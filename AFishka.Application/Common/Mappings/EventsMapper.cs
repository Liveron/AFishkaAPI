using MapsterMapper;
using System.Reflection;

namespace AFishka.Application.Common.Mappings
{
    internal class EventsMapper : Mapper
    {
        public EventsMapper()
        {
            Config.Scan(Assembly.GetCallingAssembly(), Assembly.GetExecutingAssembly());
        }
    }
}
