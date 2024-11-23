using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace hello_CSharp_Lambda;

public class Function
{
    /// <summary>
    /// Modified function that accepts any object as input and demonstrates a simple lambda expression
    /// </summary>
    /// <param name="input">The event object for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public object FunctionHandler(object input, ILambdaContext context)
    {
        // inputログ出力
        context.Logger.LogInformation($"input: {input}");
        
        // contextログ出力
        context.Logger.LogInformation($"Function name: {context.FunctionName}");
        context.Logger.LogInformation($"Remaining time: {context.RemainingTime}");
        context.Logger.LogInformation($"Memory limit: {context.MemoryLimitInMB}MB");
        
        // objectを引数にとり、文字列化＆大文字にしてstringで返すラムダ式
        Func<object, string> processInput = (obj) => $"Processed input: {obj?.ToString()?.ToUpper() ?? "NULL"}";

        // ２つのintを引数にとり、足し算をしてintで返すラムダ式
        Func<int, int, int> processCalc = (x, y) => x + y;
        
        return new
        {
            processedResult =  processInput(input),
            processedCalc = processCalc(3, 5)
        };
    }
}