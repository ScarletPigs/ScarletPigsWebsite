﻿using System.Text.Json.Serialization;

namespace ScarletPigsWebsite.Data.Models.Steamworks
{
    public class PublishedFileDetails
    {
        [JsonPropertyName("publishedfileid")]
        public string PublishedFileId { get; set; }

        [JsonPropertyName("result")]
        public int Result { get; set; }

        [JsonPropertyName("creator")]
        public string Creator { get; set; }

        [JsonPropertyName("creator_app_id")]
        public uint CreatorAppId { get; set; }

        [JsonPropertyName("consumer_app_id")]
        public uint ConsumerAppId { get; set; }

        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        [JsonPropertyName("file_size")]
        public string FileSize { get; set; }

        [JsonPropertyName("file_url")]
        public string FileUrl { get; set; }

        [JsonPropertyName("hcontent_file")]
        public string HContentFile { get; set; }

        [JsonPropertyName("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonPropertyName("hcontent_preview")]
        public string HContentPreview { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("time_created")]
        public long TimeCreated { get; set; }

        [JsonPropertyName("time_updated")]
        public long TimeUpdated { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("banned")]
        public int Banned { get; set; }

        [JsonPropertyName("ban_reason")]
        public string BanReason { get; set; }

        [JsonPropertyName("subscriptions")]
        public int Subscriptions { get; set; }

        [JsonPropertyName("favorited")]
        public int Favorited { get; set; }

        [JsonPropertyName("lifetime_subscriptions")]
        public int LifetimeSubscriptions { get; set; }

        [JsonPropertyName("lifetime_favorited")]
        public int LifetimeFavorited { get; set; }

        [JsonPropertyName("views")]
        public int Views { get; set; }

        [JsonPropertyName("tags")]
        public List<PublishedFileTag> Tags { get; set; }
    }
}
