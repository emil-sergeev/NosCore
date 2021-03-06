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

using System;
using System.Collections.Generic;
using System.Linq;
using ChickenAPI.Packets.ClientPackets.CharacterSelectionScreen;
using ChickenAPI.Packets.ClientPackets.Drops;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NosCore.Core.I18N;
using NosCore.Data.Enumerations.Map;
using NosCore.GameObject;
using NosCore.GameObject.Map;
using NosCore.GameObject.Networking.ClientSession;
using NosCore.GameObject.Providers.MapInstanceProvider;
using NosCore.GameObject.Providers.MapInstanceProvider.Handlers;
using NosCore.GameObject.Providers.MapItemProvider;
using NosCore.PacketHandlers.CharacterScreen;
using NosCore.Tests.Helpers;
using Serilog;

namespace NosCore.Tests.PacketHandlerTests
{
    [TestClass]
    public class CharNewPacketHandlerTests
    {
        private static readonly ILogger _logger = Logger.GetLoggerConfiguration().CreateLogger();
        private Character _chara;
        private CharNewPacketHandler _charNewPacketHandler;
        private ClientSession _session;

        [TestInitialize]
        public void Setup()
        {
            TestHelpers.Reset();
            _session = TestHelpers.Instance.GenerateSession();
            _chara = _session.Character;
            _session.SetCharacter(null);
            _charNewPacketHandler =
                new CharNewPacketHandler(TestHelpers.Instance.CharacterDao, TestHelpers.Instance.MinilandDao);
        }

        [TestMethod]
        public void CreateCharacterWhenInGame_Does_Not_Create_Character()
        {
            _session.SetCharacter(_chara);
            _session.Character.MapInstance =
                new MapInstance(new Map(), new Guid(), true, MapInstanceType.BaseMapInstance,
                    new MapItemProvider(new List<IEventHandler<MapItem, Tuple<MapItem, GetPacket>>>()),
                    _logger, new List<IMapInstanceEventHandler>());
            const string name = "TestCharacter";
            _charNewPacketHandler.Execute(new CharNewPacket
            {
                Name = name
            }, _session);
            Assert.IsNull(TestHelpers.Instance.CharacterDao.FirstOrDefault(s => s.Name == name));
        }

        [TestMethod]
        public void CreateCharacter()
        {
            const string name = "TestCharacter";
            _charNewPacketHandler.Execute(new CharNewPacket
            {
                Name = name
            }, _session);
            Assert.IsNotNull(TestHelpers.Instance.CharacterDao.FirstOrDefault(s => s.Name == name));
        }


        [TestMethod]
        public void InvalidName_Does_Not_Create_Character()
        {
            const string name = "Test Character";
            _charNewPacketHandler.Execute(new CharNewPacket
            {
                Name = name
            }, _session);
            Assert.IsNull(TestHelpers.Instance.CharacterDao.FirstOrDefault(s => s.Name == name));
        }

        [TestMethod]
        public void ExistingName_Does_Not_Create_Character()
        {
            const string name = "TestExistingCharacter";
            _charNewPacketHandler.Execute(new CharNewPacket
            {
                Name = name
            }, _session);
            Assert.IsFalse(TestHelpers.Instance.CharacterDao.Where(s => s.Name == name).Skip(1).Any());
        }

        [TestMethod]
        public void NotEmptySlot_Does_Not_Create_Character()
        {
            const string name = "TestCharacter";
            _charNewPacketHandler.Execute(new CharNewPacket
            {
                Name = name,
                Slot = 1
            }, _session);
            Assert.IsFalse(TestHelpers.Instance.CharacterDao.Where(s => s.Slot == 1).Skip(1).Any());
        }
    }
}