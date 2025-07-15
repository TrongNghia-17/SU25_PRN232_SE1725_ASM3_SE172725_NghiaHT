using SMMS.GrpcClient.ConsoleApp.NghiaHT.Protos;
using Grpc.Net.Client;

Console.WriteLine("");

using var channel = GrpcChannel.ForAddress("https://localhost:7167");
var clientRegistration = new RequestGRPC.RequestGRPCClient(channel);

Console.WriteLine("GET ALL --------------------------------------------------");
var requests = clientRegistration.GetAllAsync(new EmptyRequest() { });
if (requests != null && requests.Items.Count() > 0){
    foreach (var item in requests.Items)
    {
        Console.WriteLine(string.Format("{0} - {1}", item.RequestNghiaHtId, item.MedicationName));
    }
}

Console.WriteLine("GET BY ID --------------------------------------------------");
var request = clientRegistration.GetByIdAsync(new RequestNghiaHtIdRequest() { RequestNghiaHtId = 3 });
Console.WriteLine(string.Format("{0} - {1}", request.RequestNghiaHtId, request.MedicationName));

Console.WriteLine("ADD --------------------------------------------------");
var newRequest = new RequestNghiaHt
{
    MedicationCategoryQuanTnId = 1,
    MedicationName = "nghia",
    Dosage = "nghia",
    Frequency = "nghia",
    Reason = "nghia",
    Indications = "nghia",
    Quantity = 1,
    Instruction = "nghia",
    CreatedDate = "2025-05-24T17:06:06.2300000",
    IsApproved = false
};

MutationResult response = clientRegistration.CreateAsync(newRequest);
if (response.Result > 0)
{
    Console.WriteLine("New request created successfully " + response.Result);
}
else
{
    Console.WriteLine("Failed to create new request");
}

Console.WriteLine("UPDATE --------------------------------------------------");
var updateRequest = new RequestNghiaHt
{
    RequestNghiaHtId = 3,
    MedicationCategoryQuanTnId = 1,
    MedicationName = "nghiaht",
    Dosage = "nghia",
    Frequency = "nghia",
    Reason = "nghia",
    Indications = "nghia",
    Quantity = 1,
    Instruction = "nghia",
    CreatedDate = "2025-05-24T17:06:06.2300000",
    IsApproved = false
};

response = clientRegistration.UpdateAsync(updateRequest);
if (response.Result > 0)
{
    Console.WriteLine("Request updated successfully " + response.Result);
}
else
{
    Console.WriteLine("Failed to update request");
}

Console.WriteLine("DELETE --------------------------------------------------");
var deleteResponse = clientRegistration.DeleteAsync(new RequestNghiaHtIdRequest() { RequestNghiaHtId = 20 });
if (deleteResponse.Result > 0)
{
    Console.WriteLine("Request deleted successfully " + deleteResponse.Result);
}
else
{
    Console.WriteLine("Failed to delete request");
}
