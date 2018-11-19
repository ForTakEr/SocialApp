﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : ListActivity
    {
        public static List<SocialPost> posts;
        public static List<Comment> comments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            if(posts == null) TestPosts();

            ListAdapter = new PostAdapter(this, posts);
            FindViewById<Button>(Resource.Id.addPost).Click += AddPostButton;
        }

        private void AddPostButton(object sender, EventArgs e)
        {
            EditText editText = FindViewById<EditText>(Resource.Id.content);

            posts.Add(new SocialPost
            {
                Name = "Tester",
                Message = editText.Text,
                Likes = 0,
                Date = DateTimeOffset.Now,
                Comments = new List<Comment>()
            });
        }

        public void TestPosts()
        {
            posts = new List<SocialPost>();
            comments = new List<Comment>();

            Comment Comment = new Comment
            {
                Name = "Karupoeg",
                Message = "Ei kannata",
                Likes = 228
            };
            comments.Add(Comment);

            Comment = new Comment
            {
                Name = "auto24 vend",
                Message = "Müüb audit",
                Likes = 0
            };
            comments.Add(Comment);

            SocialPost post = new SocialPost
            {
                Name = "Test1",
                Message = "See sõnum on tekkinud siia ns",
                Likes = 0,
                Date = DateTimeOffset.FromUnixTimeSeconds(1541056855),
                Comments = comments
            };
            posts.Add(post);

            comments = new List<Comment>();

            Comment = new Comment
            {
                Name = "Test1. 2post",
                Message = "Test",
                Likes = 3
            };
            comments.Add(Comment);

            Comment = new Comment
            {
                Name = "Test2. 2post",
                Message = "Test",
                Likes = 5
            };
            comments.Add(Comment);

            Comment = new Comment
            {
                Name = "Test3. 2post",
                Message = "Test",
                Likes = 9
            };
            comments.Add(Comment);

            post = new SocialPost
            {
                Name = "Test2",
                Message = "Testing message",
                Likes = 0,
                Date = DateTimeOffset.FromUnixTimeSeconds(1500056855),
                Comments = comments,
                ContainsPic = true,
                Pic = Resource.Drawable.download
            };
            posts.Add(post);

            comments = new List<Comment>();

            Comment = new Comment
            {
                Name = "Test1. 3post",
                Message = "Test",
                Likes = 10
            };
            comments.Add(Comment);

            Comment = new Comment
            {
                Name = "Test2. 3post",
                Message = "Test",
                Likes = 20
            };
            comments.Add(Comment);

            Comment = new Comment
            {
                Name = "Test3. 3post",
                Message = "Test",
                Likes = 30
            };
            comments.Add(Comment);

            post = new SocialPost
            {
                Name = "Test3",
                Message = "Message to test",
                Likes = 0,
                Date = DateTimeOffset.FromUnixTimeSeconds(1305056855),
                Comments = comments
            };
            posts.Add(post);

            comments = new List<Comment>();

            Comment = new Comment
            {
                Name = "Test1. 4post",
                Message = "Test",
                Likes = 10
            };
            comments.Add(Comment);

            Comment = new Comment
            {
                Name = "Test3. 4post",
                Message = "Test",
                Likes = 10
            };
            comments.Add(Comment);

            post = new SocialPost
            {
                Name = "Test4",
                Message = "See sonum on tekkinud siia ns",
                Likes = 0,
                Date = DateTimeOffset.FromUnixTimeSeconds(1205056005),
                Comments = comments,
                ContainsPic = true,
                Pic = Resource.Drawable.iceberg
            };
            posts.Add(post);
        }
    }
}