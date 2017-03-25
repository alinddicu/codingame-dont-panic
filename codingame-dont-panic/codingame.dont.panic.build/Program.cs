namespace codingame.dont.panic.build
{
	using common.build.submit.file;

	public class Program
	{
		public static void Main(string[] args)
		{
			const string sourceFolderPath = "../../../codingame.dont.panic/";
			const string targetFilePath = "../../codingame.dont.panic.txt";
			new BuildSubmitFile().Build(sourceFolderPath, targetFilePath);
		}
	}
}
