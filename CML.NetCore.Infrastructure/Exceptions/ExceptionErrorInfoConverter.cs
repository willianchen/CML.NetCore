using CML.Lib.Domains.Entities;
using CML.Lib.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Exceptions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ExceptionErrorInfoConverter.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ExceptionErrorInfoConverter
    /// 创建标识：cml 2018/4/9 16:13:56
    /// </summary>
    public class ExceptionErrorInfoConverter : IExceptionErrorInfoConverter
    {
        /// <summary>
        /// Exception 转换 ErrorInfo
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public ErrorInfo Convert(Exception exception)
        {
            var errorInfo = CreateErrorInfoWithoutCode(exception);

            if (exception is IHasErrorCode)
            {
                errorInfo.Code = (exception as IHasErrorCode).Code;
            }

            return errorInfo;
        }


        private ErrorInfo CreateErrorInfoWithoutCode(Exception exception)
        {
            //if (SendAllExceptionsToClients)
            //{
            //return CreateDetailedErrorInfoFromException(exception);
            //   }

            if (exception is AggregateException && exception.InnerException != null)
            {
                var aggException = exception as AggregateException;
                if (aggException.InnerException is UserFriendlyException
                    )
                {
                    exception = aggException.InnerException;
                }
            }

            if (exception is UserFriendlyException)
            {
                var userFriendlyException = exception as UserFriendlyException;
                return new ErrorInfo(userFriendlyException.Message, userFriendlyException.Details);
            }


            if (exception is EntityNotFoundException)
            {
                var entityNotFoundException = exception as EntityNotFoundException;

                if (entityNotFoundException.EntityType != null)
                {
                    return new ErrorInfo(
                        string.Format(
                            "EntityNotFound",
                            entityNotFoundException.EntityType.Name,
                            entityNotFoundException.Id
                        )
                    );
                }

                return new ErrorInfo(
                    entityNotFoundException.Message
                );
            }

            if (exception is AuthorizationException)
            {
                var authorizationException = exception as AuthorizationException;
                return new ErrorInfo(authorizationException.Message);
            }

            return new ErrorInfo("InternalServerError：" + exception.Message);
        }

        private ErrorInfo CreateDetailedErrorInfoFromException(Exception exception)
        {
            var detailBuilder = new StringBuilder();

            AddExceptionToDetails(exception, detailBuilder);

            var errorInfo = new ErrorInfo(exception.Message, detailBuilder.ToString());

            return errorInfo;
        }

        private void AddExceptionToDetails(Exception exception, StringBuilder detailBuilder)
        {
            //Exception Message
            detailBuilder.AppendLine(exception.GetType().Name + ": " + exception.Message);

            //Additional info for UserFriendlyException
            if (exception is UserFriendlyException)
            {
                var userFriendlyException = exception as UserFriendlyException;
                if (!string.IsNullOrEmpty(userFriendlyException.Details))
                {
                    detailBuilder.AppendLine(userFriendlyException.Details);
                }
            }

            //Exception StackTrace
            if (!string.IsNullOrEmpty(exception.StackTrace))
            {
                detailBuilder.AppendLine("STACK TRACE: " + exception.StackTrace);
            }

            //Inner exception
            if (exception.InnerException != null)
            {
                AddExceptionToDetails(exception.InnerException, detailBuilder);
            }

            //Inner exceptions for AggregateException
            if (exception is AggregateException)
            {
                var aggException = exception as AggregateException;
                if (aggException.InnerExceptions == null)
                {
                    return;
                }

                foreach (var innerException in aggException.InnerExceptions)
                {
                    AddExceptionToDetails(innerException, detailBuilder);
                }
            }
        }



    }
}
