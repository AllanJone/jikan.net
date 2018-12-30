﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JikanDotNet.Tests
{
    public class TopTestClass
    {
		private readonly IJikan jikan;

		public TopTestClass()
		{
			jikan = new Jikan(true);
		}

		[Fact]
		public void ShouldParseTopAnime()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop()).Result;

			Assert.NotNull(top);
		}

		[Fact]
		public void ShouldParseFMA()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop()).Result;

			Assert.Equal("Fullmetal Alchemist: Brotherhood", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseFMAEpisodes()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop()).Result;

			Assert.Equal(64, top.Top.First().Episodes);
		}

		[Fact]
		public void ShouldParseKimiNoNaWaType()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop()).Result;

			Assert.Equal("Movie", top.Top.Skip(1).First().Type);
		}

		[Fact]
		public void ShouldParseKimiNoNaWaMovieList()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop(1, TopAnimeExtension.TopMovies)).Result;

			Assert.Equal("Kimi no Na wa.", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseDeathNotePopularityList()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop(1, TopAnimeExtension.TopPopularity)).Result;

			Assert.Equal("Death Note", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseLOGHOvaList()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop(1, TopAnimeExtension.TopOva)).Result;

			Assert.Equal("Ginga Eiyuu Densetsu", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseLOGHOAiringStartOvaList()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop(1, TopAnimeExtension.TopOva)).Result;

			Assert.Equal("Jan 1988", top.Top.First().AiringStart);
		}

		[Fact]
		public void ShouldParseAnimeSecondPage()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop(2)).Result;

			Assert.Contains("Ping Pong the Animation", top.Top.Select(x => x.Title));
			Assert.Contains("Yojouhan Shinwa Taikei", top.Top.Select(x => x.Title));
		}


		[Fact]
		public void ShouldParseTopManga()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop()).Result;

			Assert.NotNull(top);
		}

		[Fact]
		public void ShouldParseBerserk()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop()).Result;

			Assert.Equal("Berserk", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseBerserkStartDate()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop()).Result;

			Assert.Equal("Aug 1989", top.Top.First().PublishingStart);
		}

		[Fact]
		public void ShouldParseHakoMari()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop(1, TopMangaExtension.TopNovel)).Result;

			Assert.Equal("Monogatari Series: First Season", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseNarutoPopularity()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop(1, TopMangaExtension.TopPopularity)).Result;

			Assert.Equal("Naruto", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseNarutoTypePopularity()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop(1, TopMangaExtension.TopPopularity)).Result;

			Assert.Equal("Manga", top.Top.First().Type);
		}

		[Fact]
		public void ShouldParseKanaHanazawa()
		{
			PeopleTop top = Task.Run(() => jikan.GetPeopleTop()).Result;

			Assert.Equal("Hanazawa, Kana", top.Top.First().Name);
			Assert.Equal("花澤 香菜", top.Top.First().NameKanji);
			Assert.Equal(185, top.Top.First().MalId);
			Assert.Equal(1989, top.Top.First().Birthday.Value.Year);
			Assert.True(top.Top.First().Favorites > 60000);
		}

		[Fact]
		public void ShouldParseHiroshiKamiya()
		{
			PeopleTop top = Task.Run(() => jikan.GetPeopleTop()).Result;

			Assert.Equal("Kamiya, Hiroshi", top.Top.Skip(1).First().Name);
			Assert.Equal("神谷 浩史", top.Top.Skip(1).First().NameKanji);
			Assert.Equal(118, top.Top.Skip(1).First().MalId);
			Assert.Equal(1975, top.Top.Skip(1).First().Birthday.Value.Year);
			Assert.True(top.Top.Skip(1).First().Favorites > 50000);
		}

		[Fact]
		public void ShouldFindKentarouMiura()
		{
			PeopleTop top = Task.Run(() => jikan.GetPeopleTop(2)).Result;

			Assert.Contains("Miura, Kentarou", top.Top.Select(x => x.Name));
		}

		[Fact]
		public void ShouldParseLelouchLamperouge()
		{
			CharactersTop top = Task.Run(() => jikan.GetCharactersTop()).Result;

			Assert.Equal("Lamperouge, Lelouch", top.Top.First().Name);
			Assert.Equal("ルルーシュ・ランペルージ", top.Top.First().NameKanji);
			Assert.Equal(417, top.Top.First().MalId);
			Assert.True(top.Top.First().Favorites > 85000);
		}

		[Fact]
		public void ShouldParseLLawliet()
		{
			CharactersTop top = Task.Run(() => jikan.GetCharactersTop()).Result;

			Assert.Equal("Lawliet, L", top.Top.Skip(1).First().Name);
			Assert.Equal("エル ローライト", top.Top.Skip(1).First().NameKanji);
			Assert.Equal(71, top.Top.Skip(1).First().MalId);
			Assert.True(top.Top.Skip(1).First().Favorites > 65000);
		}

		[Fact]
		public void ShouldParseLuffyAnimeography()
		{
			CharactersTop top = Task.Run(() => jikan.GetCharactersTop()).Result;

			Assert.Equal("Monkey D., Luffy", top.Top.Skip(2).First().Name);
			Assert.Contains("One Piece", top.Top.Skip(2).First().Animeography.Select(x => x.Name));
		}

		[Fact]
		public void ShouldFindTachibanaKanade()
		{
			CharactersTop top = Task.Run(() => jikan.GetCharactersTop(2)).Result;

			Assert.Contains("Tachibana, Kanade", top.Top.Select(x => x.Name));
		}

	}
}
