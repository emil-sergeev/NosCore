﻿//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// 
// Copyright (C) 2019 - NosCore
// 
// NosCore is a free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Linq;
using ChickenAPI.Packets.ClientPackets.Inventory;
using ChickenAPI.Packets.Enumerations;
using ChickenAPI.Packets.ServerPackets.Inventory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NosCore.Core;
using NosCore.Core.I18N;
using NosCore.GameObject.Networking.ClientSession;
using NosCore.GameObject.Providers.InventoryService;
using NosCore.GameObject.Providers.ItemProvider;
using NosCore.PacketHandlers.Inventory;
using NosCore.Tests.Helpers;
using Serilog;

namespace NosCore.Tests.PacketHandlerTests
{
    [TestClass]
    public class BiPacketHandlerTests
    {
        private static readonly ILogger _logger = Logger.GetLoggerConfiguration().CreateLogger();
        private BiPacketHandler _biPacketHandler;
        private IItemProvider _item;
        private ClientSession _session;

        [TestCleanup]
        public void Cleanup()
        {
            SystemTime.Freeze(SystemTime.Now());
        }

        [TestInitialize]
        public void Setup()
        {
            SystemTime.Freeze();
            _session = TestHelpers.Instance.GenerateSession();
            _item = TestHelpers.Instance.GenerateItemProvider();
            _biPacketHandler = new BiPacketHandler(_logger);
        }

        [TestMethod]
        public void Test_Delete_FromSlot()
        {
            _session.Character.InventoryService.AddItemToPocket(InventoryItemInstance.Create(_item.Create(1012, 999), 0));
            _biPacketHandler.Execute(new BiPacket
                {Option = RequestDeletionType.Confirmed, Slot = 0, PocketType = PocketType.Main}, _session);
            var packet = (IvnPacket) _session.LastPackets.FirstOrDefault(s => s is IvnPacket);
            Assert.IsTrue(packet.IvnSubPackets.All(iv => (iv.Slot == 0) && (iv.VNum == -1)));
        }

        [TestMethod]
        public void Test_Delete_FromEquiment()
        {
            _session.Character.InventoryService.AddItemToPocket(InventoryItemInstance.Create(_item.Create(1, 1), 0));
            _biPacketHandler.Execute(new BiPacket
                {Option = RequestDeletionType.Confirmed, Slot = 0, PocketType = PocketType.Equipment}, _session);
            Assert.IsTrue(_session.Character.InventoryService.Count == 0);
            var packet = (IvnPacket) _session.LastPackets.FirstOrDefault(s => s is IvnPacket);
            Assert.IsTrue(packet.IvnSubPackets.All(iv => (iv.Slot == 0) && (iv.VNum == -1)));
        }
    }
}