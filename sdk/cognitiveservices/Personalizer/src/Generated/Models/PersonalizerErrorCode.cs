// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Personalizer.Models
{

    /// <summary>
    /// Defines values for PersonalizerErrorCode.
    /// </summary>
    public static class PersonalizerErrorCode
    {
        /// <summary>
        /// Request could not be understood by the server.
        /// </summary>
        public const string BadRequest = "BadRequest";
        /// <summary>
        /// Requested resource does not exist on the server.
        /// </summary>
        public const string ResourceNotFound = "ResourceNotFound";
        /// <summary>
        /// A generic error has occurred on the server.
        /// </summary>
        public const string InternalServerError = "InternalServerError";
        /// <summary>
        /// Invalid service configuration.
        /// </summary>
        public const string InvalidServiceConfiguration = "InvalidServiceConfiguration";
        /// <summary>
        /// Invalid policy configuration.
        /// </summary>
        public const string InvalidPolicyConfiguration = "InvalidPolicyConfiguration";
        /// <summary>
        /// Invalid policy contract.
        /// </summary>
        public const string InvalidPolicyContract = "InvalidPolicyContract";
        /// <summary>
        /// Invalid evaluation contract.
        /// </summary>
        public const string InvalidEvaluationContract = "InvalidEvaluationContract";
        /// <summary>
        /// Invalid reward request.
        /// </summary>
        public const string InvalidRewardRequest = "InvalidRewardRequest";
        /// <summary>
        /// Invalid activate event request.
        /// </summary>
        public const string InvalidEventIdToActivate = "InvalidEventIdToActivate";
        /// <summary>
        /// Invalid rank request.
        /// </summary>
        public const string InvalidRankRequest = "InvalidRankRequest";
        /// <summary>
        /// Invalid export logs request.
        /// </summary>
        public const string InvalidExportLogsRequest = "InvalidExportLogsRequest";
        /// <summary>
        /// SAS Uri must be the Uri to a container that has write permissions.
        /// </summary>
        public const string InvalidContainer = "InvalidContainer";
        /// <summary>
        /// Front end not found.
        /// </summary>
        public const string FrontEndNotFound = "FrontEndNotFound";
        /// <summary>
        /// Evaluation not found.
        /// </summary>
        public const string EvaluationNotFound = "EvaluationNotFound";
        /// <summary>
        /// Logs properties not found.
        /// </summary>
        public const string LogsPropertiesNotFound = "LogsPropertiesNotFound";
        /// <summary>
        /// Rank call returned null response.
        /// </summary>
        public const string RankNullResponse = "RankNullResponse";
        /// <summary>
        /// Failed to update configuration.
        /// </summary>
        public const string UpdateConfigurationFailed = "UpdateConfigurationFailed";
        /// <summary>
        /// Model reset failed.
        /// </summary>
        public const string ModelResetFailed = "ModelResetFailed";
    }
}
