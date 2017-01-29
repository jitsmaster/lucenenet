using Lucene.Net.Codecs.Lucene45;
using Lucene.Net.Index;

namespace Lucene.Net.Codecs.DiskDV
{
    /*
     * Licensed to the Apache Software Foundation (ASF) under one or more
     * contributor license agreements.  See the NOTICE file distributed with
     * this work for additional information regarding copyright ownership.
     * The ASF licenses this file to You under the Apache License, Version 2.0
     * (the "License"); you may not use this file except in compliance with
     * the License.  You may obtain a copy of the License at
     *
     *     http://www.apache.org/licenses/LICENSE-2.0
     *
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     */

    /// <summary>
    /// Norms format that keeps all norms on disk
    /// </summary>
    public sealed class DiskNormsFormat : NormsFormat
    {
        public override DocValuesConsumer NormsConsumer(SegmentWriteState state)
        {
            return new Lucene45DocValuesConsumer(state, DATA_CODEC, DATA_EXTENSION, META_CODEC, META_EXTENSION);
        }

        public override DocValuesProducer NormsProducer(SegmentReadState state)
        {
            return new DiskDocValuesProducer(state, DATA_CODEC, DATA_EXTENSION, META_CODEC, META_EXTENSION);
        }

        private static readonly string DATA_CODEC = "DiskNormsData";
        private static readonly string DATA_EXTENSION = "dnvd";
        private static readonly string META_CODEC = "DiskNormsMetadata";
        private static readonly string META_EXTENSION = "dnvm";
    }
}