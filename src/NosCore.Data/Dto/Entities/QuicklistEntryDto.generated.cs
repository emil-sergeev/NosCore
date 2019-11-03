//  __  _  __    __   ___ __  ___ ___  
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

using System.ComponentModel.DataAnnotations;
using NosCore.Data.I18N;
using NosCore.Data.Dto;
using NosCore.Data.StaticEntities;
using NosCore.Data.DataAttributes;
using NosCore.Data.Enumerations.I18N;
using Mapster;

namespace NosCore.Data.Dto
{
	/// <summary>
	/// Represents a DTO class for NosCore.Database.Entities.QuicklistEntry.
	/// NOTE: This class is generated by GenerateDtos.tt
	/// </summary>
	public class QuicklistEntryDto : IDto
	{
		[AdaptIgnore]
		public CharacterDto Character { get; set; }

	 	public long CharacterId { get; set; }

	 	public short Morph { get; set; }

	 	public short Pos { get; set; }

	 	public short Q1 { get; set; }

	 	public short Q2 { get; set; }

	 	public short Slot { get; set; }

	 	public ChickenAPI.Packets.Enumerations.QSetType Type { get; set; }

	 	[Key]
		public System.Guid Id { get; set; }

	 }
}