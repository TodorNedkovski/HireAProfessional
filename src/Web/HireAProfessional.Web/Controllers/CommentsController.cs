namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Comments;
    using HireAProfessionalML.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Server.IIS.Core;
    using Microsoft.Extensions.ML;
    using Microsoft.ML;

    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly PredictionEnginePool<ModelInput, ModelOutput> ml;

        public CommentsController(
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager,
            PredictionEnginePool<ModelInput, ModelOutput> ml)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
            this.ml = ml;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string postId, string parentId, string content)
        {
            var mi = new ModelInput();
            mi.SentimentText = content;

            var a = ConsumeModel.Predict(mi);
            bool isRude = a.Prediction == "1";

            var posterId = this.userManager.GetUserId(this.User);

            await this.commentsService.CreateComment(posterId, parentId, postId, content, isRude);

            return this.RedirectToAction("ById", "JobPosts", new { id = postId });
        }
    }
}
