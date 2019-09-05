Imports Grpc.Net.Client
Imports ProtoBuf.Grpc.Client
Imports Shared_VB

Module Program
    Sub Main()
        DoIt().Wait()
    End Sub

    Async Function DoIt() As Task
        GrpcClientFactory.AllowUnencryptedHttp2 = True
        Using http = GrpcChannel.ForAddress("http://localhost:10042")
            Dim client = http.CreateGrpcService(Of ICalculator)
            Dim result = Await client.MultiplyAsync(New MultiplyRequest With {.X = 12, .Y = 4})
            Console.WriteLine(result.Result)
        End Using
    End Function
End Module
