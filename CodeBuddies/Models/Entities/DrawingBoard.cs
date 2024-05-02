using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public class DrawingBoard : IDrawingBoard
    {
        #region Fields
        private string filePath;
        #endregion

        #region Properties
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        #endregion

        public DrawingBoard(string filePath)
        {
            FilePath = filePath;
        }

        #region Methods

        /// <summary>
        /// Draw a point at x, y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Draw(int x, int y)
        {
            // Draw the point at x, y
        }

        /// <summary>
        /// Save the drawing to the file
        /// </summary>
        public void Save()
        {
            // Save the drawing to the file
        }

        /// <summary>
        /// Render the drawing
        /// </summary>
        public void Render()
        {
            // Render the drawing
        }

        /// <summary>
        /// Erase the point at x, y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Erase(int x, int y)
        {
            // Erase the point at x, y
        }
        #endregion
    }
}
