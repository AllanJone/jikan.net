﻿using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JikanDotNet.Tests
{
	public class AdvancedSearchTestClass
	{
		private readonly IJikan jikan;

		public AdvancedSearchTestClass()
		{
			jikan = new Jikan(true);
		}

		[Theory]
		[InlineData("berserk")]
		[InlineData("danganronpa")]
		[InlineData("death")]
		public void ShouldReturnNotNullSearchAnime(string query)
		{
			var searchConfig = new AnimeSearchConfig
			{
				Type = AnimeType.TV
			};

			AnimeSearchResult returnedAnime = Task.Run(() => jikan.SearchAnime(query, searchConfig)).Result;

			Assert.NotNull(returnedAnime);
		}

		[Fact]
		public void ShouldReturnDanganronpaAnime()
		{
			var searchConfig = new AnimeSearchConfig
			{
				Type = AnimeType.TV
			};

			AnimeSearchResult danganronpaAnime = Task.Run(() => jikan.SearchAnime("danganronpa", searchConfig)).Result;

			Assert.Equal(1, danganronpaAnime.ResultLastPage);
		}

		[Fact]
		public void ShouldFilterFairyTailAnimeScore()
		{
			var searchConfig = new AnimeSearchConfig
			{
				Type = AnimeType.TV,
				Score = 8
			};

			AnimeSearchResult danganronpaAnime = Task.Run(() => jikan.SearchAnime("Fairy Tail", searchConfig)).Result;

			Assert.Equal("Fairy Tail (2014)", danganronpaAnime.Results.First().Title);
			Assert.Equal("Fairy Tail", danganronpaAnime.Results.Skip(1).First().Title);
		}

		[Theory]
		[InlineData("berserk")]
		[InlineData("monster")]
		[InlineData("death")]
		public void ShouldReturnNotNullSearchManga(string query)
		{
			var searchConfig = new MangaSearchConfig
			{
				Type = MangaType.Manga
			};

			MangaSearchResult returnedManga = Task.Run(() => jikan.SearchManga(query, searchConfig)).Result;

			Assert.NotNull(returnedManga);
		}

		[Fact]
		public void ShouldReturnDanganronpaManga()
		{
			var searchConfig = new MangaSearchConfig
			{
				Type = MangaType.Manga

			};
			MangaSearchResult danganronpaManga = Task.Run(() => jikan.SearchManga("danganronpa", searchConfig)).Result;

			Assert.Equal(1, danganronpaManga.ResultLastPage);
		}

		[Fact]
		public void ShouldReturnDanganronpaMangaScore()
		{
			var searchConfig = new MangaSearchConfig
			{
				Type = MangaType.Manga,
				Score = 8

			};
			MangaSearchResult danganronpaManga = Task.Run(() => jikan.SearchManga("danganronpa", searchConfig)).Result;

			Assert.Equal("New Danganronpa V3: Minna no Koroshiai Shingakki Comic Anthology", danganronpaManga.Results.First().Title);
		}
	}
}