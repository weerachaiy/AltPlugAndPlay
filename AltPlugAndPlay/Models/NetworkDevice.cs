﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltPlugAndPlay.Models
{
    public class NetworkDevice
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("deviceType")]
        public virtual NetworkDeviceType DeviceType { get; set; }
        [JsonProperty("hostname")]
        public string Hostname { get; set; }
        [JsonProperty("domainName")]
        public string DomainName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("ipAddress")]
        public string IPAddress { get; set; }
        [JsonProperty("uplinks")]
        public List<NetworkDeviceLink> Uplinks { get; set; }
    }
}
