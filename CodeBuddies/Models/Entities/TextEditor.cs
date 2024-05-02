using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public class TextEditor : ITextEditor
    {
        #region Fields
        private string textColor;
        private List<string> filePaths;
        #endregion

        #region Properties
        public string TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }
        public List<string> FilePaths
        {
            get { return filePaths; }
            set { filePaths = value; }
        }
        #endregion

        public TextEditor(string textColor, List<string> filesPaths)
        {
            TextColor = textColor;
            FilePaths = filesPaths;
        }

        #region Methods

        /// <summary>
        /// Insert text at row, column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="text"></param>
        public void Insert(int row, int column, string text)
        {
            // Insert text at row, column
        }

        /// <summary>
        /// Delete text at row, column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void Delete(int row, int column)
        {
            // Delete at row, column
        }

        /// <summary>
        /// Select the text from startRow, startColumn to endRow, endColumn
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <param name="endRow"></param>
        /// <param name="endColumn"></param>
        public void SelectSelection(int startRow, int startColumn, int endRow, int endColumn)
        {
            // Select the text from startRow, startColumn to endRow, endColumn
        }

        /// <summary>
        /// Open the file
        /// </summary>
        /// <param name="filePath"></param>
        public void OpenFile(string filePath)
        {
            // Open the file
        }
        #endregion
    }
}
