using GhostLyzer.Module.GhostApi.Models;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
    {
        #region Create
        /// <summary>
        /// Creates a webhook.
        /// </summary>
        /// <param name="webhook">Webhook to create.</param>
        /// <returns>Returns the created webhook.</returns>
        public Webhook CreateWebhook(Webhook webhook)
        {
            var request = PrepareWebhookCreateRequest(webhook);
            return Execute<WebhookRequest>(request).Webhooks[0];
        }

        /// <summary>
        /// Creates a webhook asynchronously.
        /// </summary>
        /// <param name="webhook">Webhook to create.</param>
        /// <returns>Returns the created webhook.</returns>
        public async Task<Webhook> CreateWebhookAsync(Webhook webhook)
        {
            var request = PrepareWebhookCreateRequest(webhook);
            var response = await ExecuteAsync<WebhookRequest>(request);
            return response.Webhooks[0];
        }

        #endregion

        #region Update

        /// <summary>
        /// Updates a webhook.
        /// </summary>
        /// <param name="webhook">Webhook to update.</param>
        /// <returns>Returns the updated webhook.</returns>
        public Webhook UpdateWebhook(Webhook webhook)
        {
            var request = PrepareWebhookUpdateRequest(webhook);
            return Execute<WebhookRequest>(request).Webhooks[0];
        }

        /// <summary>
        /// Updates a webhook asynchronously.
        /// </summary>
        /// <param name="webhook">Webhook to update.</param>
        /// <returns>Returns the updated webhook.</returns>
        public async Task<Webhook> UpdateWebhookAsync(Webhook webhook)
        {
            var request = PrepareWebhookUpdateRequest(webhook);
            var response = await ExecuteAsync<WebhookRequest>(request);
            return response.Webhooks[0];
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes a webhook.
        /// </summary>
        /// <param name="webhookID">ID of the webhook to delete.</param>
        /// <returns>Returns True if delete succeeds; otherwise False.</returns>
        public bool DeleteWebhook(string webhookID)
        {
            var request = PrepareWebhookDeleteRequest(webhookID);
            return Execute(request);
        }

        /// <summary>
        /// Deletes a webhook asynchronously.
        /// </summary>
        /// <param name="webhookID">ID of the webhook to delete.</param>
        /// <returns>Returns True if delete succeeds; otherwise False.</returns>
        public async Task<bool> DeleteWebhookAsync(string webhookID)
        {
            var request = PrepareWebhookDeleteRequest(webhookID);
            return await ExecuteAsync(request);
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Prepares a RestRequest for creating a webhook.
        /// </summary>
        /// <param name="webhook">Webhook to create.</param>
        /// <returns>A RestRequest that can be used to create the webhook.</returns>
        private RestRequest PrepareWebhookCreateRequest(Webhook webhook)
        {
            var request = CreateRequest(Method.Post, "webhooks");
            request.AddJsonBody(new WebhookRequest { Webhooks = new List<Webhook> { webhook } });
            return request;
        }

        /// <summary>
        /// Prepares a RestRequest for deleting a webhook.
        /// </summary>
        /// <param name="webhookID">ID of the webhook to delete.</param>
        /// <returns>A RestRequest that can be used to delete the webhook.</returns>
        private RestRequest PrepareWebhookDeleteRequest(string webhookID)
        {
            var request = CreateRequest(Method.Delete, "webhooks", webhookID);
            return request;
        }

        /// <summary>
        /// Prepares a RestRequest for updating a webhook.
        /// </summary>
        /// <param name="webhook">Webhook to update.</param>
        /// <returns>A RestRequest that can be used to update the webhook.</returns>
        private RestRequest PrepareWebhookUpdateRequest(Webhook webhook)
        {
            var request = CreateRequest(Method.Put, "webhooks", webhook.ID);
            request.AddJsonBody(new WebhookRequest { Webhooks = new List<Webhook> { webhook } });
            return request;
        }

        #endregion
    }
}
