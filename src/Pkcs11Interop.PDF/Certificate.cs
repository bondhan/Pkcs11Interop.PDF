﻿/*
 *  Pkcs11Interop.PDF - Integration layer for Pkcs11Interop 
 *                      and iText (iTextSharp) libraries
 *  Copyright (c) 2013-2016 JWC s.r.o. <http://www.jwc.sk>
 *  Author: Jaroslav Imrich <jimrich@jimrich.sk>
 *
 *  Licensing for open source projects:
 *  Pkcs11Interop.PDF is available under the terms of the GNU Affero General 
 *  Public License version 3 as published by the Free Software Foundation.
 *  Please see <http://www.gnu.org/licenses/agpl-3.0.html> for more details.
 *
 *  Licensing for other types of projects:
 *  Pkcs11Interop.PDF is available under the terms of flexible commercial license.
 *  Please contact JWC s.r.o. at <info@pkcs11interop.net> for more details.
 */

using System;
using Org.BouncyCastle.Crypto;
using BCX509 = Org.BouncyCastle.X509;

namespace Net.Pkcs11Interop.PDF
{
    /// <summary>
    /// Represents certificate accessible via PKCS#11 interface
    /// </summary>
    public class Certificate
    {
        /// <summary>
        /// Hex encoded string with identifier (value of CKA_ID attribute) of the certificate
        /// </summary>
        private string _id = null;

        /// <summary>
        /// Hex encoded string with identifier (value of CKA_ID attribute) of the certificate
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Label (value of CKA_LABEL attribute) of the certificate
        /// </summary>
        private string _label = null;

        /// <summary>
        /// Label (value of CKA_LABEL attribute) of the certificate
        /// </summary>
        public string Label
        {
            get
            {
                return _label;
            }
        }

        /// <summary>
        /// DER encoded certificate data
        /// </summary>
        private byte[] _data = null;

        /// <summary>
        /// DER encoded certificate data
        /// </summary>
        public byte[] Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// Certified public key
        /// </summary>
        private AsymmetricKeyParameter _publicKey = null;

        /// <summary>
        /// Certified public key
        /// </summary>
        public AsymmetricKeyParameter PublicKey
        {
            get
            {
                return _publicKey;
            }
        }

        /// <summary>
        /// Intitializes class instance
        /// </summary>
        /// <param name="id">Hex encoded string with identifier (value of CKA_ID attribute) of the certificate</param>
        /// <param name="label">Label (value of CKA_LABEL attribute) of the certificate</param>
        /// <param name="data">DER encoded certificate data (value of CKA_VALUE attribute)</param>
        internal Certificate(string id, string label, byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            BCX509.X509Certificate cert = CertUtils.ToBouncyCastleObject(data);

            _id = id;
            _label = label;
            _data = data;
            _publicKey = cert.GetPublicKey();
        }
    }
}
