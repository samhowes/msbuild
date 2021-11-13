// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

using Microsoft.Build.Framework;
using Microsoft.Build.Shared;
using TaskItem = Microsoft.Build.Execution.ProjectItemInstance.TaskItem;

namespace Microsoft.Build.BackEnd
{
    /// <summary>
    /// A packet to encapsulate a BuildEventArg logging message.
    /// Contents:
    /// Build Event Type
    /// Build Event Args
    /// </summary>
    public class LogMessagePacket : LogMessagePacketBase
    {
        /// <summary>
        /// Encapsulates the buildEventArg in this packet.
        /// </summary>
        public LogMessagePacket(KeyValuePair<int, BuildEventArgs>? nodeBuildEvent)
            : base(nodeBuildEvent, new TargetFinishedTranslator(TranslateTargetFinishedEvent))
        {
        }

        /// <summary>
        /// Constructor for deserialization
        /// </summary>
        private LogMessagePacket(ITranslator translator)
            : base(translator)
        {
        }

        /// <summary>
        /// Factory for serialization
        /// </summary>
        static public INodePacket FactoryForDeserialization(ITranslator translator)
        {
            return new LogMessagePacket(translator);
        }

        /// <summary>
        /// Translate the TargetOutputs for the target finished event.
        /// </summary>
        private static void TranslateTargetFinishedEvent(ITranslator translator, TargetFinishedEventArgs finishedEvent)
        {
            List<TaskItem> targetOutputs = null;
            if (translator.Mode == TranslationDirection.WriteToStream)
            {
                if (finishedEvent.TargetOutputs != null)
                {
                    targetOutputs = new List<TaskItem>();
                    foreach (TaskItem item in finishedEvent.TargetOutputs)
                    {
                        targetOutputs.Add(item);
                    }
                }
            }

            translator.Translate<TaskItem>(ref targetOutputs, TaskItem.FactoryForDeserialization);

            if (translator.Mode == TranslationDirection.ReadFromStream)
            {
                finishedEvent.TargetOutputs = targetOutputs;
            }
        }
    }
}
