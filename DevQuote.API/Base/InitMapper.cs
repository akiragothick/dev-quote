using AutoMapper;

namespace DevQuote.API.Base
{
    public static class InitMapper
    {
        public static IMapper mapper;
        public static void Start()
        {
            if (mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Models.User, DataTransferObject.User>().MaxDepth(7);
                    cfg.CreateMap<Models.Professional, DataTransferObject.Professional>().MaxDepth(7);
                    cfg.CreateMap<Models.ProjectType, DataTransferObject.ProjectType>().MaxDepth(7);
                    cfg.CreateMap<Models.ProjectTypeMechanism, DataTransferObject.ProjectTypeMechanism>().MaxDepth(7);
                    cfg.CreateMap<Models.AssignProject, DataTransferObject.AssignProject>().MaxDepth(7);


                    cfg.CreateMap<DataTransferObject.User, Models.User>().MaxDepth(7);
                    cfg.CreateMap<DataTransferObject.Professional, Models.Professional>().MaxDepth(7);
                    cfg.CreateMap<DataTransferObject.ProjectType, Models.ProjectType>().MaxDepth(7);
                    cfg.CreateMap<DataTransferObject.ProjectTypeMechanism, Models.ProjectTypeMechanism>().MaxDepth(7);
                    cfg.CreateMap<DataTransferObject.AssignProject, Models.AssignProject>().MaxDepth(7);
                });

                mapper = config.CreateMapper();
            }
        }
    }
}
