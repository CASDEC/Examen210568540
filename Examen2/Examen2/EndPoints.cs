using Examen2.Contratos;
using Examen2.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Examen2
{
    public class EndPoints
    {
        private readonly ILogger<EndPoints> _logger;
        private readonly IPreguntas _preguntas;

        public EndPoints(ILogger<EndPoints> logger, IPreguntas preguntas)
        {
            _logger = logger;
            _preguntas = preguntas;
        }

        [Function("InsertarPedidoDetalle")]
        [OpenApiOperation("InsertarPedidoDetalle", "InsertarPedidoDetalle", Description = "Insertar")]
        [OpenApiRequestBody("application/json", typeof(PedidoDetalle), Description = "Introduzaca el Objeto")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(PedidoDetalle), Description = "Todo bien")]

        public async Task<HttpResponseData> InsertarPedidoDetalle([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Insertar Pedido Detalle");
            var pedidodetalle = await req.ReadFromJsonAsync<PedidoDetalle>();
            bool success = await _preguntas.RegistrarPedidoDetalle(pedidodetalle);
            if (success)
            {
                var respuesta = req.CreateResponse(HttpStatusCode.OK);
                return respuesta;
            }
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }


        [Function("ActualizarPedidoDetalle")]
        [OpenApiOperation("ActualizarPedidoDetalle", "ActualizarPedidoDetalle", Description = "Actualizar")]
        [OpenApiRequestBody("application/json", typeof(PedidoDetalle), Description = "Introduzaca el Objeto")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(PedidoDetalle), Description = "Todo bien")]

        public async Task<HttpResponseData> ActualizarPedidoDetalle([HttpTrigger(AuthorizationLevel.Function, "put")] HttpRequestData req)
        {
            _logger.LogInformation("Actualizar Pedido Detalle");
            var pedidodetalle = await req.ReadFromJsonAsync<PedidoDetalle>();
            bool success = await _preguntas.ActualizarPedidoDetalle(pedidodetalle);
            if (success)
            {
                var respuesta = req.CreateResponse(HttpStatusCode.OK);
                return respuesta;
            }
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Function("ListarReporte")]
        [OpenApiOperation("ListarReporte", "ListarReporte", Description = "Listar")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(DTOReporte), Description = "Todo bien")]

        public async Task<HttpResponseData> ListarRepote([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("Listar Reporte");
            var res = req.CreateResponse(HttpStatusCode.OK);
            await res.WriteAsJsonAsync(await _preguntas.ListarReporteCFNS());
            return res;
        }
    }
}
