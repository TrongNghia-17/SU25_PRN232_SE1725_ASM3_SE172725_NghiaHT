using Grpc.Core;
using SMMS.GrpcService.NghiaHT.Protos;
using SMMS.Repositories.NghiaHT.Models;
using SMMS.Services.NghiaHT;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SMMS.GrpcService.NghiaHT.Services
{
    public class RequestGRPCService : RequestGRPC.RequestGRPCBase
    {
        private readonly IServiceProviders _serviceProviders;

        public RequestGRPCService(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        public override async Task<RequestNghiaHtList> GetAllAsync(EmptyRequest request, ServerCallContext context)
        {
            var result = new RequestNghiaHtList();

            try
            {
                var requestNghiaHt = await _serviceProviders.RequestNghiaHtService.GetAllAsync();


                //var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };


                //var cashDepositSlipJsonString = JsonSerializer.Serialize(requestNghiaHt, opt);


                //var items = JsonSerializer.Deserialize<List<RequestNghiaHt>>(cashDepositSlipJsonString, opt);

                result.Items.AddRange(requestNghiaHt.Select(r => new SMMS.GrpcService.NghiaHT.Protos.RequestNghiaHt
                {
                    RequestNghiaHtId = r.RequestNghiaHtid,
                    MedicationCategoryQuanTnId = r.MedicationCategoryQuanTnid ?? 0, 
                    MedicationName = r.MedicationName ?? string.Empty,
                    Dosage = r.Dosage ?? string.Empty,
                    Frequency = r.Frequency ?? string.Empty,
                    Reason = r.Reason ?? string.Empty,
                    Instruction = r.Instruction ?? string.Empty,
                    //Form = r.Form ?? string.Empty,
                    Quantity = r.Quantity ?? 0,
                    //Strength = r.Strength ?? string.Empty,
                    Indications = r.Indications ?? string.Empty,
                    //Contraindications = r.Contraindications ?? string.Empty,
                    CreatedDate = r.CreatedDate?.ToString("o") ?? string.Empty,
                    //StartDate = r.StartDate?.ToString("o") ?? string.Empty,
                    IsApproved = r.IsApproved
                }));


                //result.Items.AddRange(items);



            }
            catch (Exception ex) { }

            return result;
        }

        public override async Task<SMMS.GrpcService.NghiaHT.Protos.RequestNghiaHt> GetByIdAsync(RequestNghiaHtIdRequest request, ServerCallContext context)
        {
            //try
            //{
            var requestNghiaHt = await _serviceProviders.RequestNghiaHtService.GetByIdAsync(int.Parse(request.RequestNghiaHtId));


            //    var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };


            //    var cashDepositSlipJsonString = JsonSerializer.Serialize(requestNghiaHt, opt);


            //    var item = JsonSerializer.Deserialize<RequestNghiaHt>(cashDepositSlipJsonString, opt);

            //    return item;
            //}
            //catch (Exception ex) { }

            //return new RequestNghiaHt();

            return new SMMS.GrpcService.NghiaHT.Protos.RequestNghiaHt
            {
                RequestNghiaHtId = requestNghiaHt.RequestNghiaHtid,
                MedicationCategoryQuanTnId = requestNghiaHt.MedicationCategoryQuanTnid ?? 0,
                MedicationName = requestNghiaHt.MedicationName ?? string.Empty,
                Dosage = requestNghiaHt.Dosage ?? string.Empty,
                Frequency = requestNghiaHt.Frequency ?? string.Empty,
                Reason = requestNghiaHt.Reason ?? string.Empty,
                Instruction = requestNghiaHt.Instruction ?? string.Empty,
                Quantity = requestNghiaHt.Quantity ?? 0,
                Indications = requestNghiaHt.Indications ?? string.Empty,
                CreatedDate = requestNghiaHt.CreatedDate?.ToString("o") ?? string.Empty,
                IsApproved = requestNghiaHt.IsApproved
            };
        }

        //public override async Task<MutationResult> CreateAsync(RequestNghiaHt request, ServerCallContext context)
        //{
        //    try
        //    {

        //        var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };


        //        var protoJsonString = JsonSerializer.Serialize(request, opt);


        //        var item = JsonSerializer.Deserialize<SMMS.Repositories.NghiaHT.Models.RequestNghiaHt>(protoJsonString, opt);

        //        var result = await _serviceProviders.RequestNghiaHtService.CreateAsync(item);

        //        return new MutationResult() { Result = result };
        //    }
        //    catch (Exception ex) { }

        //    return new MutationResult() { Result = 0 };
        //}
    }
}
