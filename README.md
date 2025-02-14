# VCETODE

VCETODE is a lightweight, feature-rich text editor for Windows 11 inspired by macOS aesthetics and the best parts of VSCode. It now features:

- **LEARN Mode:** A distraction-free mode with advanced features (like intellisense) turned off.
- **QUICK-SHIP Mode:** A full-featured mode for power users—complete with code intellisense, plugin support, Git integration, etc.
- **Competitive Programming Mode:** Designed for competitive programmers. Simply type a question number, choose your platform (LeetCode, HackerRank, CodeForces) and language, and let the built-in API search fetch a solution!

## Features

- **Custom Editor Control:** Built with WinUI 3 and .NET 7, with production-ready syntax highlighting (currently for Python keywords, easily extensible).
- **Smooth UI & Animations:** Consistent Mac-inspired transitions and a sleek dark theme (extremely dark purple, black, and neon green accents).
- **Robust Error Logging:** A Logger class that writes errors and info to a log file in the user's local app data folder.
- **Modular Plugin System:** Dynamically load plugins (with a sample plugin included) to extend VCETODE’s functionality.
- **Competitive Programming Integration:** Real API calls (replace endpoints with real ones) to fetch coding solutions from popular platforms.
- **Git Integration:** Perform Git commits directly from the editor using LibGit2Sharp.
- **Custom Terminal:** An embedded terminal that processes commands with error logging.

## Getting Started

### Prerequisites

- **Windows 11**
- **Visual Studio 2022 (or later)** with WinUI 3 and .NET 7 workloads
- **.NET 7 SDK**

### Clone & Build

```bash
git clone https://github.com/yourusername/VCETODE.git
cd VCETODE
