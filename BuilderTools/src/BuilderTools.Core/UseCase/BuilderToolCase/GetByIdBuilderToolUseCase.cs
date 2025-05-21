using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.BuilderToolCase
{
    public class GetByIdBuilderToolUseCase
    {
        private readonly IBuilderToolRepository _builderToolRepository;

        public GetByIdBuilderToolUseCase(IBuilderToolRepository builderToolRepository)
        {
            _builderToolRepository = builderToolRepository;
        }

        public async Task<BuilderToolDto> ExecuteAsync(Guid builderToolId)
        {
            var builderTool = await _builderToolRepository.GetByIdAsync(builderToolId);
            return builderTool.ToModel();
        }
    }
}
