﻿namespace AutoTagger.Clarifai.Standard
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoTagger.Contract;

    using global::Clarifai.API;
    using global::Clarifai.DTOs.Inputs;

    public class ClarifaiImageTagger : ITaggingProvider
    {
        private const string ClarifaiApiKey = "c8747218d8bc496a8de7e761d8f593e6";

        private readonly ClarifaiClient client;

        public ClarifaiImageTagger()
        {
            this.client = new ClarifaiClient(ClarifaiApiKey);
        }

        public IEnumerable<string> GetTagsForImageBytes(byte[] imageBytes)
        {
            var clarifaiInput = new ClarifaiFileImage(imageBytes);
            return this.GetTagsForInput(clarifaiInput);
        }

        public IEnumerable<string> GetTagsForImageUrl(string imageUrl)
        {
            var clarifaiInput = new ClarifaiURLImage(imageUrl);
            return this.GetTagsForInput(clarifaiInput);
        }

        private IEnumerable<string> GetTagsForInput(IClarifaiInput clarifaiInput)
        {
            var result = this.client.PublicModels.GeneralModel.Predict(clarifaiInput).ExecuteAsync().Result;
            return !result.IsSuccessful
                ? Enumerable.Empty<string>()
                : result.Get().Data.Select(x => x.Name);
        }
    }
}
