﻿using Swifter.RW;

using System;
using System.Collections;

namespace Swifter.RW
{
    internal sealed class EnumeratorInterface<T> : IValueInterface<T> where T : IEnumerator
    {
        public T ReadValue(IValueReader valueReader)
        {
            throw new NotSupportedException();
        }

        public void WriteValue(IValueWriter valueWriter, T value)
        {
            if (value is null)
            {
                valueWriter.DirectWrite(null);

                return;
            }

            var enumeratorReader = new EnumeratorReader<T>();

            enumeratorReader.Initialize(value);

            valueWriter.WriteArray(enumeratorReader);
        }
    }
}