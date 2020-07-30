﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// The <see cref="DataLakeFileClient"/> allows you to manipulate Azure Data Lake append blob-based files.
    /// </summary>
    public class DataLakeAppendFileClient : DataLakeFileClient
    {
        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a file.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="CreateIfNotExists"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory.
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public new virtual Response<PathInfo> Create(
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return base.CreateInternal(
                    resourceType: PathResourceType.File,
                    httpHeaders: httpHeaders,
                    metadata: metadata,
                    permissions: permissions,
                    umask: umask,
                    conditions: conditions,
                    blobType: BlobType.Appendblob,
                    async: false,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="Create"/> operation creates a file.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="CreateIfNotExists"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory.
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public new virtual async Task<Response<PathInfo>> CreateAsync(
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return await base.CreateInternal(
                    resourceType: PathResourceType.File,
                    httpHeaders: httpHeaders,
                    metadata: metadata,
                    permissions: permissions,
                    umask: umask,
                    conditions: conditions,
                    blobType: BlobType.Appendblob,
                    async: true,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Create

        #region Create If Not Exists
        /// <summary>
        /// The <see cref="CreateIfNotExists"/> operation creates a file.
        /// If the file already exists, it is not changed.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory..
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public new virtual Response<PathInfo> CreateIfNotExists(
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(CreateIfNotExists)}");

            try
            {
                scope.Start();

                return base.CreateIfNotExistsInternal(
                    PathResourceType.File,
                    BlobType.Appendblob,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    async: false,
                    cancellationToken)
                    .EnsureCompleted();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="CreateIfNotExists"/> operation creates a file.
        /// If the file already exists, it is not changed.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory..
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public new virtual async Task<Response<PathInfo>> CreateIfNotExistsAsync(
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(CreateIfNotExists)}");

            try
            {
                scope.Start();

                return await base.CreateIfNotExistsInternal(
                    PathResourceType.File,
                    BlobType.Appendblob,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    async: true,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Create If Not Exists

        #region Concurrent Append
        /// <summary>
        /// The <see cref="ConcurrentAppend"/> operation uploads data to be appended to a file.
        /// Data can only be appended to a file.
        /// To apply perviously uploaded data to a file, call Flush Data.
        /// Append is currently limited to 4000 MB per request.  To upload large files all at once, consider using <see cref="DataLakeFileClient.Upload(Stream)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="contentHash">
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the state
        /// of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response ConcurrentAppend(
            Stream content,
            byte[] contentHash = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Append)}");

            try
            {
                scope.Start();

                return ConcurrentAppendInternal(
                    content,
                    contentHash,
                    progressHandler,
                    async: false,
                    cancellationToken)
                    .EnsureCompleted();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="ConcurrentAppendAsync"/> operation uploads data to be appended to a file.  Data can only be appended to a file.
        /// To apply perviously uploaded data to a file, call Flush Data.
        /// Append is currently limited to 4000 MB per request.  To upload large files all at once, consider using <see cref="DataLakeFileClient.UploadAsync(Stream)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="contentHash">
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the state
        /// of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> ConcurrentAppendAsync(
            Stream content,
            byte[] contentHash = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Append)}");

            try
            {
                scope.Start();

                return await ConcurrentAppendInternal(
                    content,
                    contentHash,
                    progressHandler,
                    async: true,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="ConcurrentAppendInternal"/> operation uploads data to be appended to a file.  Data can only be appended to a file.
        /// To apply perviously uploaded data to a file, call Flush Data.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="contentHash">
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the state
        /// of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal virtual async Task<Response> ConcurrentAppendInternal(
            Stream content,
            byte[] contentHash,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakeFileClient)))
            {
                content = content?.WithNoDispose().WithProgress(progressHandler);
                Pipeline.LogMethodEnter(
                    nameof(DataLakeFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");
                try
                {
                    Response<PathConcurrentAppendInternal> response = await DataLakeRestClient.Path.ConcurrentAppendAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: DfsUri,
                        version: Version.ToVersionString(),
                        body: content,
                        contentLength: content?.Length ?? 0,
                        transactionalContentHash: contentHash,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return response.GetRawResponse();
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakeFileClient));
                }
            }
        }
        #endregion Concurrent Append
    }
}