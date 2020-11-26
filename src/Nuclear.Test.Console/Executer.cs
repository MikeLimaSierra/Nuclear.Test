﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

using log4net;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Test.Helpers;
using Nuclear.Test.Results;

namespace Nuclear.Test.Console {
    internal class Executer {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Executer));

        private readonly Configuration _configuration;

        private readonly IFactory _factory;

        private readonly List<String> _headerContent = new List<String>();

        private readonly AssemblyLocator _locator;

        private readonly CountdownEvent _remotesFinishedEvent = new CountdownEvent(0);

        #endregion

        #region properties

        internal ITestResultEndPoint Results { get; }

        #endregion

        #region ctors

        public Executer(Configuration configuration, IFactory factory) {
            Throw.If.Object.IsNull(configuration, nameof(configuration));
            Throw.If.Object.IsNull(factory, nameof(factory));

            _configuration = configuration;
            _factory = factory;

            _factory.Create(out ITestResultEndPoint results);
            Results = results;

            _headerContent.Add(@" _   _               _                    _____           _   ");
            _headerContent.Add(@"| \ | | _   _   ___ | |  ___   __ _  _ __|_   _|___  ___ | |_ ");
            _headerContent.Add(@"|  \| || | | | / __|| | / _ \ / _` || '__| | | / _ \/ __|| __|");
            _headerContent.Add(@"| |\  || |_| || (__ | ||  __/| (_| || | _  | ||  __/\__ \| |_ ");
            _headerContent.Add(@"|_| \_| \__,_| \___||_| \___| \__,_||_|(_) |_| \___||___/ \__|");
            _headerContent.Add(@"  ____                           _                            ");
            _headerContent.Add(@" / ___| ___   _ __   ___   ___  | |  ___                      ");
            _headerContent.Add(@"| |    / _ \ | '_ \ / __| / _ \ | | / _ \                     ");
            _headerContent.Add(@"| |___| (_) || | | |\__ \| (_) || ||  __/                     ");
            _headerContent.Add(@" \____|\___/ |_| |_||___/ \___/ |_| \___|                     ");
            _headerContent.Add(@"                                                              ");

            _locator = new AssemblyLocator() {
                SearchDirectory = new DirectoryInfo(Environment.ExpandEnvironmentVariables(_configuration.Locator.SearchDirectory)),
                SearchDepth = _configuration.Locator.SearchDepth,
                SearchPattern = _configuration.Locator.SearchPattern,
                IgnoredDirectoryNames = _configuration.Locator.IgnoredDirectoryNames
            };
        }

        #endregion

        #region methods

        internal void Execute() {
            RuntimesHelper.TryGetCurrentRuntime(out RuntimeInfo currentRuntime);

            ConsoleHelper.SetConsoleTitle(currentRuntime);
            ConsoleHelper.PrintProcessInfo(currentRuntime, _headerContent);

            IEnumerable<FileInfo> assemblies = _locator.DiscoverAssemblies();
            IEnumerable<RemoteInfo> remoteInfos = CreateRemoteInfos(assemblies);
            IEnumerable<ProxyRemote> remotes = CreateRemotes(remoteInfos);

            foreach(ProxyRemote remote in remotes) {
                _remotesFinishedEvent.AddCount();

                remote.Execute();

                if(_configuration.Execution.AssembliesInSequence) {
                    _remotesFinishedEvent.Wait();
                }
            }

            _remotesFinishedEvent.Wait();
        }

        private IEnumerable<RemoteInfo> CreateRemoteInfos(IEnumerable<FileInfo> assemblies) {
            return null;
        }

        private IEnumerable<ProxyRemote> CreateRemotes(IEnumerable<RemoteInfo> remoteInfos) {
            return null;
        }

        #endregion

    }
}
