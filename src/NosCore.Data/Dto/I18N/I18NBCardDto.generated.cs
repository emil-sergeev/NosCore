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

namespace NosCore.Data.I18N
{
	/// <summary>
	/// Represents a DTO class for NosCore.Database.Entities.I18NBCard.
	/// NOTE: This class is generated by GenerateDtos.tt
	/// </summary>
	public class I18NBCardDto : II18NDto
	{
		[Key]
		public int I18NbCardId { get; set; }

	 	public string Key { get; set; }

	 	public NosCore.Data.Enumerations.RegionType RegionType { get; set; }

	 	public string Text { get; set; }

	 }
}