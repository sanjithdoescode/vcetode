using System;
using LibGit2Sharp;
using VCETODE.Core;

namespace VCETODE.GitIntegration
{
    /// <summary>
    /// Handles Git operations using LibGit2Sharp.
    /// </summary>
    public class GitManager
    {
        public void CommitChanges(string repoPath, string message)
        {
            try
            {
                using (var repo = new Repository(repoPath))
                {
                    Commands.Stage(repo, "*");
                    Signature author = new Signature("VCETODE User", "user@example.com", DateTime.Now);
                    repo.Commit(message, author, author);
                    Logger.LogInfo("Committed changes successfully.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error committing changes", ex);
            }
        }
    }
}
