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

using ChickenAPI.Packets.ClientPackets.Warehouse;
using NosCore.Data;
using NosCore.Data.Enumerations.Miniland;
using NosCore.GameObject;
using NosCore.GameObject.HttpClients.WarehouseHttpClient;
using NosCore.GameObject.Networking.ClientSession;
using NosCore.GameObject.Providers.ItemProvider.Item;
using NosCore.GameObject.Providers.MinilandProvider;

namespace NosCore.PacketHandlers.Warehouse
{
    public class DepositPacketHandler : PacketHandler<DepositPacket>, IWorldPacketHandler
    {
        private readonly IMinilandProvider _minilandProvider;
        private readonly IWarehouseHttpClient _warehouseHttpClient;

        public DepositPacketHandler(IMinilandProvider minilandProvider, IWarehouseHttpClient warehouseHttpClient)
        {
            _minilandProvider = minilandProvider;
            _warehouseHttpClient = warehouseHttpClient;
        }

        public override void Execute(DepositPacket depositPacket, ClientSession clientSession)
        {
            IItemInstance itemInstance = null;
            short slot = 0;
            var warehouseItems = _warehouseHttpClient.DepositItem(clientSession.Character.CharacterId,
                WarehouseType.Warehouse, itemInstance, slot);
        }
    }
}