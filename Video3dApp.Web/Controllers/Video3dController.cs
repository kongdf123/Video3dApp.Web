using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Video3dApp.Web.Filters;

namespace Video3dApp.Controllers
{
	public class Video3dController : Controller
	{
		public ActionResult Detail() {
			return View();
		}

		public void CheckDownloadProgress() {			
			if ( (string)Session["fileDownload"] == "true" ) {
				Response.AppendCookie(new HttpCookie("fileDownload", "true") {Path = "/" });
			}
		}

		[AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post | HttpVerbs.Options), FileDownload]
		public void ReadVideo() {
			var reqRange = Request.Headers["Range"];
			string[] reqBlockRange = null;
			if ( !string.IsNullOrEmpty(reqRange) ) {
				reqBlockRange = reqRange.Replace("bytes=", "").Split('-');
				Response.StatusCode = 206;
				Response.AddHeader("status", "206");
			}

			Response.AddHeader("accept-ranges", "bytes");
			Response.AddHeader("access-control-allow-methods", "HEAD, GET, OPTIONS");
			Response.AddHeader("access-control-allow-origin", "*");
			Response.AddHeader("cache-control", "public, max-age=30726563");
			Response.AddHeader("content-disposition", $"attachment;  filename=VRBrandUSA3.mp4");
			Response.ContentType = "video/mp4";

			string fileName = Server.MapPath("/UploadFiles/VRBrandUSA3.mp4");

			using ( var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite) )
			using (var reader=new BinaryReader(stream)) {
				long fileSize = stream.Length;

				long startPosition = 0;
				long partialSize = fileSize;
				if ( reqBlockRange != null ) {
					startPosition = Convert.ToInt32(reqBlockRange[0]);
					partialSize = fileSize - startPosition;
				}

				//Read partial content into the buffer with a specified size
				byte[] buffer = new byte[(int)partialSize];
				// go to offset address 
				reader.BaseStream.Seek(startPosition, SeekOrigin.Begin);

				// fill buffer from starting at address to address + BlockSise
				reader.Read(buffer, 0, (int)partialSize);
				Response.AddHeader("content-range", $"bytes {startPosition}-{startPosition + partialSize - 1}/{fileSize}");
				Response.AddHeader("Content-Length", $"{partialSize}");
				Response.BinaryWrite(buffer);
			}
		}
	}
}