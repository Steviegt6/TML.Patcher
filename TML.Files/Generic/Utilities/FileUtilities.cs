﻿using System.IO;
using System.IO.Compression;

namespace TML.Files.Generic.Utilities
{
    /// <summary>
    ///     Provides numerous helper-methods for messing with files.
    /// </summary>
    public static class FileUtilities
    {
        /// <summary>
        ///     Uses a <see cref="MemoryStream"/> and <see cref="DeflateStream"/> to decompress a file, given the data and decompressed size.
        /// </summary>
        public static byte[] DecompressFile(byte[] data, int decompressedSize)
        {
            MemoryStream dataStream = new(data);
            byte[] decompressed = new byte[decompressedSize];

            using DeflateStream deflatedStream = new(dataStream, CompressionMode.Decompress);
            deflatedStream.Read(decompressed, 0, decompressedSize);

            return decompressed;
        }

        /// <summary>
        ///     Uses a <see cref="MemoryStream"/> and <see cref="DeflateStream"/> to compress a file, given the data.
        /// </summary>
        public static byte[] CompressFile(byte[] data)
        {
            MemoryStream dataStream = new(data);
            MemoryStream compressStream = new();

            DeflateStream deflateStream = new(compressStream, CompressionMode.Compress);
            dataStream.CopyTo(deflateStream);
            deflateStream.Dispose();

            return compressStream.ToArray();
        }
    }
}