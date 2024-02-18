using DotnetGeminiSDK.Model;
using DotnetGeminiSDK.Model.Request;
using DotnetGeminiSDK.Model.Response;
using Content = DotnetGeminiSDK.Model.Request.Content;

namespace DotnetGeminiSDK.Client.Interfaces;

public interface IGeminiClient
{
    Task<GeminiMessageResponse?> TextPrompt(
        string message,
        GenerationConfig? generationConfig = null,
        SafetySetting? safetySetting = null
    );

    Task<GeminiMessageResponse?> TextPrompt(
        List<Content> messages,
        GenerationConfig? generationConfig = null,
        SafetySetting? safetySetting = null
    );

    Task<GeminiMessageResponse?> ImagePrompt(string message, byte[] image, ImageMimeType imageMimeType);

    Task<GeminiMessageResponse?> ImagePrompt(string message, string base64Image, ImageMimeType imageMimeType);
}