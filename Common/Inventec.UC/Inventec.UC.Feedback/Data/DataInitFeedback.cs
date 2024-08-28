﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventec.UC.Feedback.Data
{
    public class DataInitFeedback
    {
        internal Inventec.Token.ClientSystem.ClientTokenManager clientTokenManager;
        internal Inventec.Common.WebApiClient.ApiConsumer sdaConsumer;
        public DataInitFeedback(Inventec.Token.ClientSystem.ClientTokenManager clientToken, Inventec.Common.WebApiClient.ApiConsumer sdaconsumer)
        {
            this.clientTokenManager = clientToken;
            this.sdaConsumer = sdaconsumer;
        }
    }
}
