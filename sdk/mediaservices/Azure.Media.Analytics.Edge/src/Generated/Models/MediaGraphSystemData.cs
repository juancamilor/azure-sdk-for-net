// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.Media.Analytics.Edge.Models
{
    /// <summary> The system data for a resource. This is used by both topologies and instances. </summary>
    public partial class MediaGraphSystemData
    {
        /// <summary> Initializes a new instance of MediaGraphSystemData. </summary>
        public MediaGraphSystemData()
        {
        }

        /// <summary> Initializes a new instance of MediaGraphSystemData. </summary>
        /// <param name="createdAt"> The timestamp of resource creation (UTC). </param>
        /// <param name="lastModifiedAt"> The timestamp of resource last modification (UTC). </param>
        internal MediaGraphSystemData(DateTimeOffset? createdAt, DateTimeOffset? lastModifiedAt)
        {
            CreatedAt = createdAt;
            LastModifiedAt = lastModifiedAt;
        }

        /// <summary> The timestamp of resource creation (UTC). </summary>
        public DateTimeOffset? CreatedAt { get; set; }
        /// <summary> The timestamp of resource last modification (UTC). </summary>
        public DateTimeOffset? LastModifiedAt { get; set; }
    }
}
