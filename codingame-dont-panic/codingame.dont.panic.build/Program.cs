namespace codingame.dont.panic.build
{
	using System.IO;
	using common.build.submit.file;

	public class Program
	{
		public static void Main(string[] args)
		{
			var sourceFolderPath = new DirectoryInfo("../../../codingame.dont.panic/");
			var targetFilePath = new FileInfo("../../codingame.dont.panic.txt");
			new BuildSubmitFile().Build(sourceFolderPath, targetFilePath);
		}
	}
}
