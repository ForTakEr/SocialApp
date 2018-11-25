using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace App1
{
    [Activity(Label = "CommentActivity")]
    public class CommentActivity : ListActivity
    {
        Button cmtSubmitBtn;
        ListView cmtList;
        EditText cmtInputText;
        List<Comment> comments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CommentsActivity);
            //Define Widgets
            cmtSubmitBtn = FindViewById<Button>(Resource.Id.cmtSubmitBtn);
            cmtList = FindViewById<ListView>(Resource.Id.cmtListView);
            cmtInputText = FindViewById<EditText>(Resource.Id.cmtInputText);
            //Get intents from CustomRow
            comments = JsonConvert.DeserializeObject<List<Comment>>(Intent.GetStringExtra("Comments"));

            //Add new comment button
            cmtSubmitBtn.Click += CmtSubmitBtn_Click;
            cmtList.Adapter = new CommentAdapter(this, comments);
        }

        private void CmtSubmitBtn_Click(object sender, EventArgs e)
        {
            var commentBtn = (Button)sender;
            int position = (int)commentBtn.Tag;

            MainActivity.posts[position].Comments.Add(new Comment
            {
                Name = "User",
                Message = cmtInputText.Text,
                Likes = 0
            });
            cmtInputText.Text = "";
            cmtList.Adapter = new CommentAdapter(this, MainActivity.posts[position].Comments);
        }
    }
    }